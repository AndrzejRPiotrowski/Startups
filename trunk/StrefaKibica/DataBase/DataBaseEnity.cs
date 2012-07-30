using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace DataBaseEntity
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


        public int ParserAddDisciple(string name)
        {
            int? ret = data.AddDisciplines(name).FirstOrDefault();
            if(!ret.HasValue)
            {
                return 0;
            }
            return ret.Value;
        }

        public void ParserAddEvent(string fullName, DateTime startDate, DateTime endDate, int disciplinesId )
        {
            data.AddEvent(fullName, startDate, endDate, disciplinesId);
        }

       

    }
}
