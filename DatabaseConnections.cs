using System;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace Buldoc_Reader_Take_4
{
    public class DatabaseConnections
    {
        MySqlConnection connection;
        public DatabaseConnections() {

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties/serviceDependencies.json");

            // Read the entire JSON file as a string
            string jsonContent = File.ReadAllText(filePath);

            // Parse the JSON string into a JObject
            JObject jsonObject = JObject.Parse(jsonContent);

            // Access the "DefaultConnection" property from the "ConnectionStrings" section
            string defaultConnectionString = jsonObject["dependencies"]["ConnectionStrings"]["DefaultConnection"].ToString();

            Console.WriteLine("Default Connection String: " + defaultConnectionString);


            connection = new MySqlConnection(defaultConnectionString.ToString());

           
        }

        public List<AudioRecord> generateAudio()
        {
            List<AudioRecord> records = new List<AudioRecord>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM audioRecords";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("ID");
                            string name = reader.GetString("recordingName");
                            string url = reader.GetString("recordingURL");
                            string date = reader.GetString("recordingDate");
                            string length = reader.GetString("recordingLength");
                            string description = reader.GetString("recordingDescription");

                            AudioRecord audioRecord = new AudioRecord(ID, name, url, date, length, description);
                            records.Add(audioRecord);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public List<VideoRecord> generateVideo()
        {
            List<VideoRecord> records = new List<VideoRecord>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM videoRecords";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("ID");
                            string name = reader.GetString("videoName");
                            string url = reader.GetString("videoURL");
                            string description = reader.GetString("videoDescription");
                            string length = reader.GetString("videoLength");
                            string date = reader.GetString("videoDate");
                            string location = reader.GetString("videoLocation");

                            VideoRecord videoRecord = new VideoRecord(ID, name, url, description, length, date, location);
                            records.Add(videoRecord);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public List<ImageRecord> generateImages()
        {
            List<ImageRecord> records = new List<ImageRecord>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM pictureRecords";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("ID");
                            string name = reader.GetString("pictureName");
                            int pictureNumber = reader.GetInt32("pictureNumber");
                            string url = reader.GetString("pictureURL");
                            string date = reader.GetString("pictureDate");
                            string description = reader.GetString("pictureDescription");

                            ImageRecord imageRecord = new ImageRecord(ID, name, pictureNumber, url, date, description);
                            records.Add(imageRecord);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public List<SourceRecord> generateSources()
        {
            List<SourceRecord> records = new List<SourceRecord>();
            try
            {
                connection.Open();
                string query = "select * from sourceRecords x order by x.sourceNumber ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("ID");
                            string extension = reader.GetString("fileExtension");
                            int sourceNumber = reader.GetInt32("sourceNumber");
                            string url = reader.GetString("sourceURL");

                            SourceRecord source = new SourceRecord(ID, extension, sourceNumber, url);
                            records.Add(source);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public List<RestrictedRecord> generateRestrictedContent()
        {
            List<RestrictedRecord> records = new List<RestrictedRecord>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM restrictedRecords";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("ID");
                            string name = reader.GetString("recordName");
                            int sourceNumber = reader.GetInt32("recordNumber");
                            string url = reader.GetString("recordURL");

                            RestrictedRecord source = new RestrictedRecord(ID, name, sourceNumber, url);
                            records.Add(source);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public bool checkUser(string username)
        {
            bool found = false;
            try
            {
                connection.Open();
                string query = $"select * from users x where x.userName = '{username.ToLower()}'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string user = reader.GetString("userName");
                            if (user != null)
                            {
                                found = true;
                                break;
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return found;

        }

        public bool checkPassword(string username, string hashed)
        {
            bool correct = false;
            try
            {
                connection.Open();
                string query = $"select * from users x where x.userName = '{username.ToLower()}' and x.password = '{hashed}'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string user = reader.GetString("userName");
                            string password = reader.GetString("password");
                            if (password != null && password == hashed)
                            {
                                correct = true;
                                break;
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return correct;

        }
    }
}