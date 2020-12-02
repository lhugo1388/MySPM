using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySPM
{
    [DynamoDBTable("alumno")]
    public class Alumno
    {
        [DynamoDBHashKey]
        public int id { get; set; }
        public string nombre { get; set; }
        public string psw { get; set; }
        public string usuario { get; set; }

        public async void Save()
        {
            await ConnectionManager.Context.SaveAsync<Alumno>(this);
        }

        public Alumno LoadById(int idx)
        {
            Task<Alumno> task = ConnectionManager.Context.LoadAsync<Alumno>(idx);
            task.Wait();
            return task.Result;
        }

        public static async Task<List<Alumno>> LoadAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
           
            List<ScanCondition> scanFilter = new List<ScanCondition>();
            AsyncSearch<Alumno> search = ConnectionManager.Context.ScanAsync<Alumno>(scanFilter);

            do
            {
                Task<List<Alumno>> tarea = search.GetNextSetAsync();
                tarea.Wait();
                List<Alumno> results = tarea.Result;

                foreach(Alumno item in results)
                {
                    alumnos.Add(item);
                }
            } while (!search.IsDone);

            return alumnos;
        }

        public async void Delete()
        {
            await ConnectionManager.Context.DeleteAsync<Alumno>(this);
        }

    }
}
