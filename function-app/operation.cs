using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using com.glc.demo.calculator;

namespace com.glc.demo.calculator
{
    public interface IOperation
    {
        public static decimal Calculate()
        {
            throw new Exception("To Implement");
        }
    }
    public static class Operation
    {

        private enum Operator
        {
            Add,
            Sub,
            Mul,
            Div,
            Undefined
        };

        private static Operator GetOperatorByName(string operatorName)
        {
            try
            {
                return (Operator)Enum.Parse(typeof(Operator), operatorName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Operator.Undefined;
            }
        }


        public static string Calculate(float firstNumber, float secondNumber, string operatorName)
        {
            try
            {
                Operator operation = GetOperatorByName(operatorName);
                float resultNumber;
                string sign;

                switch (operation)
                {
                    case Operator.Add: resultNumber = CalculateAddition(firstNumber, secondNumber); sign = "+"; break;
                    case Operator.Sub: resultNumber = CalculateSubtration(firstNumber, secondNumber); sign = "-"; break;
                    case Operator.Mul: resultNumber = CalculateMultiplication(firstNumber, secondNumber); sign = "*"; break;
                    case Operator.Div: resultNumber = CalculateDivision(firstNumber, secondNumber); sign = "/"; break;
                    default: return $"{operatorName} ({firstNumber}, {secondNumber}) has an error: Operation is not defined yet.";
                }
                // Save in Database
                SaveToDataBase(firstNumber, secondNumber, operatorName, resultNumber);

                //Return result
                return $" {firstNumber} {sign} {secondNumber} = {resultNumber}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return $"{operatorName} ({firstNumber}, {secondNumber}) has an error: {ex.Message}";
            }
        }

        private static void SaveToDataBase(float firstNumber, float secondNumber, string operationName, float resultNumber)
        {
            //Validate if resultNumber is Infinitive
            if (float.IsInfinity(resultNumber) || float.IsNegativeInfinity(resultNumber) || float.IsPositiveInfinity(resultNumber)) throw new Exception("Result is Infinity.");
            if (float.IsNaN(resultNumber)) throw new Exception("Result is NaN number.");
            using SqlConnection con = new SqlConnection(Environment.GetEnvironmentVariable("SQLConnectionString"));
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "usp_add_calculation";
                cmd.Parameters.AddWithValue("@FirstNumber", firstNumber);
                cmd.Parameters.AddWithValue("@SecondNumber", secondNumber);
                cmd.Parameters.AddWithValue("@OperationName", operationName);
                cmd.Parameters.AddWithValue("@ResultNumber", resultNumber);

                cmd.ExecuteNonQuery();
                Console.WriteLine("New calculation is saved in Database.");
            }
        }

        private static float CalculateAddition(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static float CalculateSubtration(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        private static float CalculateMultiplication(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private static float CalculateDivision(float firstNumber, float secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}