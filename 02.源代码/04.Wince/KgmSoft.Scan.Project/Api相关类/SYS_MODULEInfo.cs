using System; 
using System.Collections.Generic;
using System.Text;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// SYS_MODULEInfo
    /// </summary> 
    public class SYS_MODULEInfo
    {
        #region Field Members

        private string m_Moduleid = System.Guid.NewGuid().ToString(); //          
        private string m_Modulename; //          
        private string m_Modulemenu; //          
        private string m_Menuicon; //          
        private string m_Moduleform; //          
        private string m_Menuform; //          
        private string m_Moduleparent; //          
        private string m_Moduleflag; //          
        private bool m_Moduleshow = false; //          
        private bool m_Moduleevent = false; //          
        private string m_Descrption; //      
        private string m_ForwardForm;
        private float? m_moduleIndex;

        #endregion

        #region Property Members
        public virtual float? ModuleIndex
        {
            get
            {
                return this.m_moduleIndex;
            }
            set
            {
                this.m_moduleIndex = value;
            }

        }
        public virtual string ForwardForm
        {
            get
            {
                return this.m_ForwardForm;
            }
            set
            {
                this.m_ForwardForm = value;
            }
        }

        public virtual string Moduleid
        {
            get
            {
                return this.m_Moduleid;
            }
            set
            {
                this.m_Moduleid = value;
            }
        }

        public virtual string Modulename
        {
            get
            {
                return this.m_Modulename;
            }
            set
            {
                this.m_Modulename = value;
            }
        }

        public virtual string Modulemenu
        {
            get
            {
                return this.m_Modulemenu;
            }
            set
            {
                this.m_Modulemenu = value;
            }
        }

        public virtual string Menuicon
        {
            get
            {
                return this.m_Menuicon;
            }
            set
            {
                this.m_Menuicon = value;
            }
        }

        public virtual string Moduleform
        {
            get
            {
                return this.m_Moduleform;
            }
            set
            {
                this.m_Moduleform = value;
            }
        }

        public virtual string Menuform
        {
            get
            {
                return this.m_Menuform;
            }
            set
            {
                this.m_Menuform = value;
            }
        }

        public virtual string Moduleparent
        {
            get
            {
                return this.m_Moduleparent;
            }
            set
            {
                this.m_Moduleparent = value;
            }
        }

        public virtual string Moduleflag
        {
            get
            {
                return this.m_Moduleflag;
            }
            set
            {
                this.m_Moduleflag = value;
            }
        }

        public virtual bool Moduleshow
        {
            get
            {
                return this.m_Moduleshow;
            }
            set
            {
                this.m_Moduleshow = value;
            }
        }

        public virtual bool Moduleevent
        {
            get
            {
                return this.m_Moduleevent;
            }
            set
            {
                this.m_Moduleevent = value;
            }
        }

        public virtual string Descrption
        {
            get
            {
                return this.m_Descrption;
            }
            set
            {
                this.m_Descrption = value;
            }
        }


        #endregion

    }
}
