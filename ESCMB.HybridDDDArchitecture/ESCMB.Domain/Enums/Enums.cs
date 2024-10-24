﻿namespace ESCMB.Domain
{
    /// <summary>
    /// Las enumeraciones deben ir definidas aqui
    /// </summary>

    public class Enums
    {
        /// <summary>
        /// Ejemplo de enumeracion Dummy
        /// </summary>
        public enum DummyValues
        {
            value1,
            value2,
            value3,
        }

        public enum CustomerStatus
        {
            PendingConfirmation,
            Confirmed,
            Active,
        }

        public enum AccountStatus
        {
            Active,
            Blocked,
            Cancel,
        }
    }
}
