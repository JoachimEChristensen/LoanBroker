using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Normalizer
{
    class Program
    {
        private static InputMessage _inputMessage;
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;

            while (true)
            {
                _inputMessage = new InputMessage();
                bool success = GetMessage();
                if (success)
                {
                    NormalizeAndSendMessage();
                }
            }
        }

        static bool GetMessage()
        {
            string input = RabbitMq.RabbitMq.Output("PBAG3_Normalizer");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InputMessage));
                StringReader stringReader = new StringReader(input);
                _inputMessage = (InputMessage)serializer.Deserialize(stringReader);

                return true;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("There is an error in XML document") && !input.Contains("Overflow: numeric value"))
                {
                    Console.WriteLine(e.Message);
                }
                // One of the schools banks failed.
                // Or JSON.

                try
                {
                    _inputMessage = JsonConvert.DeserializeObject<InputMessage>(input);

                    return true;
                }
                catch (Exception exception)
                {
                    if (!input.Contains("Overflow: numeric value"))
                    {
                        Console.WriteLine(exception.Message);
                    }
                    // One of the schools banks failed.
                }
            }

            return false;
        }

        static void NormalizeAndSendMessage()
        {
            OutputMessage output = new OutputMessage();

            #region SSN

            if (_inputMessage.ssn != null)
            {
                if (!_inputMessage.ssn.Contains("-"))
                {
                    int zerosToAddInt = 10 - _inputMessage.ssn.Length;
                    string zerosToAddString = "";

                    for (int i = 0; i < zerosToAddInt; i++)
                    {
                        zerosToAddString += "0";
                    }
                    _inputMessage.ssn = _inputMessage.ssn.Insert(0, zerosToAddString);

                    _inputMessage.ssn = _inputMessage.ssn.Insert(6, "-");
                }
                output.Ssn = _inputMessage.ssn;
            }
            else if (_inputMessage.Ssn != null)
            {
                if (!_inputMessage.Ssn.Contains("-"))
                {
                    int zerosToAddInt = 10 - _inputMessage.Ssn.Length;
                    string zerosToAddString = "";

                    for (int i = 0; i < zerosToAddInt; i++)
                    {
                        zerosToAddString += "0";
                    }
                    _inputMessage.Ssn = _inputMessage.Ssn.Insert(0, zerosToAddString);

                    _inputMessage.Ssn = _inputMessage.Ssn.Insert(6, "-");
                }
                output.Ssn = _inputMessage.Ssn;
            }

            #endregion

            #region InterestRate

            if (Math.Abs(_inputMessage.interest) > 0.0001)
            {
                output.InterestRate = _inputMessage.interest;
            }
            else if (Math.Abs(_inputMessage.interestRate) > 0.0001)
            {
                output.InterestRate = _inputMessage.interestRate;
            }

            #endregion

            string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(output);

            bool success = RabbitMq.RabbitMq.Input("PBAG3_Aggregator", jsonObject);
        }
    }
}
