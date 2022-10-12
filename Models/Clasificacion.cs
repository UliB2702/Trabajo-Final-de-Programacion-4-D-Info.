using System.Collections.Generic;

namespace TP_Final.Models;

public class Clasificacion
{
    private int _idClasificacion;
    private string _nombre;
    private string _logo;

    public int IdClasificacion
    {
        get{
            return _idClasificacion;
        }
        set{
            _idClasificacion = value;
        }
    }

    public string Nombre
    {
        get{
            return _nombre;
        }
        set{
            _nombre = value;
        }
    }

    public string Logo
    {
        get{
            return _logo;
        }
        set{
            _logo = value;
        }
    }
}