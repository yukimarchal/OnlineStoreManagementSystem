using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class Delivery
    {
        #region Fields

        private Guid _deliveryId;
        private EnumDeliveryCompany _company;
        private DateTime _deliveringDate;
        private DateTime? _deliveredDate;

        #endregion

        #region Constructors

        internal Delivery()
        {
            DeliveryId = Guid.NewGuid();
        }

        public Delivery(EnumDeliveryCompany company, DateTime deliveringDate, DateTime deliveredDate)
        {
            DeliveryId = Guid.NewGuid();
            Company = company;
            DeliveringDate = DateTime.Now.AddDays(5);
        }

        #endregion

        #region Properties

        public Guid DeliveryId
		{
			get { return _deliveryId; }
			private set { _deliveryId = value; }
		}		

		public EnumDeliveryCompany Company
		{
			get { return _company; }
			set { _company = value; }
		}        

        public DateTime DeliveringDate
        {
            get { return _deliveringDate; }
            internal set { _deliveringDate = value; }
        }        

		public DateTime? DeliveredDate
		{
			get { return _deliveredDate; }
			internal set { _deliveredDate = value; }
		}

        #endregion

        #region Methods

        public void ShowContents()
        {
            Console.WriteLine($"Delivery ID : {DeliveryId}");
            Console.WriteLine($"Delivery company : {Company}");
            Console.WriteLine($"Estimated delivery date : {DeliveringDate}");
            
            if(DeliveredDate != null)
            {
                Console.WriteLine($"Delivered date : {DeliveredDate}");
            }           
        }

        #endregion
    }
}
