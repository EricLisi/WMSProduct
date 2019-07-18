using System;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// SYS_USERSInfo
    /// </summary>
    [Serializable]
    public class SYS_USERSInfo
    {
        #region Field Members

        private string m_Userid = System.Guid.NewGuid().ToString(); //          
        private string m_Username; //          
        private string m_Notes; //          
        private string m_Udefine1; //À˘ Ù≤ø√≈          
        private string m_Udefine2; //          
        private string m_Udefine3; //          
        private string m_Udefine4; //          
        private string m_Udefine5; //          
        private string m_Udefine6; //          
        private string m_Password; //          

        #endregion

        #region Property Members

        public virtual string Userid
        {
            get
            {
                return this.m_Userid;
            }
            set
            {
                this.m_Userid = value;
            }
        }

        public virtual string Username
        {
            get
            {
                return this.m_Username;
            }
            set
            {
                this.m_Username = value;
            }
        }

        public virtual string Notes
        {
            get
            {
                return this.m_Notes;
            }
            set
            {
                this.m_Notes = value;
            }
        }

        public virtual string Udefine1
        {
            get
            {
                return this.m_Udefine1;
            }
            set
            {
                this.m_Udefine1 = value;
            }
        }

        public virtual string Udefine2
        {
            get
            {
                return this.m_Udefine2;
            }
            set
            {
                this.m_Udefine2 = value;
            }
        }

        public virtual string Udefine3
        {
            get
            {
                return this.m_Udefine3;
            }
            set
            {
                this.m_Udefine3 = value;
            }
        }

        public virtual string Udefine4
        {
            get
            {
                return this.m_Udefine4;
            }
            set
            {
                this.m_Udefine4 = value;
            }
        }

        public virtual string Udefine5
        {
            get
            {
                return this.m_Udefine5;
            }
            set
            {
                this.m_Udefine5 = value;
            }
        }

        public virtual string Udefine6
        {
            get
            {
                return this.m_Udefine6;
            }
            set
            {
                this.m_Udefine6 = value;
            }
        }

        public virtual string Password
        {
            get
            {
                return this.m_Password;
            }
            set
            {
                this.m_Password = value;
            }
        }


        #endregion

    }
}