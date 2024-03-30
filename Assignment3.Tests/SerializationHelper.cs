using System;
using System.IO;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName">File name to save serialized data</param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(users.GetType());
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users from a file
        /// </summary>
        /// <param name="fileName">File name containing serialized data</param>
        /// <returns>Deserialized list of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (ILinkedListADT)serializer.ReadObject(stream);
            }
        }
    }
}
