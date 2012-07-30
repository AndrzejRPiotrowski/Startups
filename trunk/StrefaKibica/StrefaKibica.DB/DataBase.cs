using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrefaKibica.DB
{
    public class DataBase
    {
        strefakibicaEntities _data;

        strefakibicaEntities data
        {
            get
            {
                if (_data == null)
                {
                    _data = new strefakibicaEntities();
                }
                return _data;
            }
        }


        public List<EventTypes> GetEventTypes()
        {
            return data.EventTypes.ToList();
        }

    }
}
