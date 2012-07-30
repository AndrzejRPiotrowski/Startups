using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Library.Mvvm.Base
{
    public class QuestionBase
    {
        public virtual object QuestionObject { set; get; }

        public QuestionBase()
        {
        }

        public QuestionBase(object QuestionObject)
        {
            this.QuestionObject = QuestionObject;
        }
    }
}
