using System;

namespace PathfinderDb.Models
{
    public sealed class Document
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public T ReadContentAs<T>()
        {
            if (string.IsNullOrEmpty(this.Content))
            {
                return default(T);
            }

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));

            using (var stream = new System.IO.MemoryStream())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(this.Content);
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                return (T)serializer.ReadObject(stream);
            }
        }

        public void WriteContent<T>(T content)
        {
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));

            using (var stream = new System.IO.MemoryStream())
            {
                serializer.WriteObject(stream, content);
                this.Content = System.Text.Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
