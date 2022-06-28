using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardat 
{
    public static void guardarPartida(posicioAlMon dades)//Aquest s'encarrega de guardar
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GuardarPartida guardar = new GuardarPartida(dades);

        formatter.Serialize(stream, guardar);
        stream.Close();
    }

    public static GuardarPartida cargarPartida()//Aquest s'encarrega de cargar
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GuardarPartida guardar = formatter.Deserialize(stream) as GuardarPartida;
            stream.Close();

            return guardar;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
