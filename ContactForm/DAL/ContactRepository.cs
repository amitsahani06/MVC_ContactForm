using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactForm.DAL
{
    public class ContactRepository : IContact
    {
        private ContactEntities dbContext;
        private bool disposed;
        public ContactRepository(ContactEntities contactEntities)
        {
            dbContext = contactEntities;
        }

        public int Insert(ContactUsViewModel record)
        {
            if(record != null)
            {
                ContactDetail contactDetail = new ContactDetail();
                contactDetail.FirstName = record.FirstName;
                contactDetail.LastName = record.LastName;
                contactDetail.Email = record.Email;
                contactDetail.PhoneNo = record.PhoneNo;
                contactDetail.ContactPurpose = record.ContactPurposeText;
                contactDetail.Message = record.Message;

                dbContext.ContactDetails.Add(contactDetail);
                return dbContext.SaveChanges();
            }

            return 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    dbContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}