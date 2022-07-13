
using mdl = FarmshareAdmin.Models;
using utl = FarmshareAdmin.Utilities;
using vm = FarmshareAdmin.ViewModels;

/*
 *  This class manages the creation of instances of the FarmshareEntities dbset, and provides a method to save changes.
 *  It can be used to commit changes from one or more entities as a single transaction.
 */

namespace FarmshareAdmin.BusinessAreaLayer
{
    public class UnitOfWork : IDisposable
    {
        public mdl.ACF_FarmshareContext _context;
        private utl.Error error;

        public UnitOfWork(mdl.ACF_FarmshareContext context, utl.icLogging logging)
        {
            _context = context;
            error = new utl.Error(logging);
        }

        public async Task<List<vm.VmMessage>> SaveAsync(string locationIdentifier)
        {
            List<vm.VmMessage> messages = new();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException du)
            {
                vm.VmMessage.AddErrorMessage(messages, du.InnerException.ToString());
            }
            catch (Exception ex)
            {
                error.logError(locationIdentifier, ex);
                vm.VmMessage.AddErrorMessage(messages, "Database detected error - contact OIT support");
            }
            return messages;
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public const int SqlServerViolationOfUniqueIndex = 2601;
        public const int SqlServerViolationOfUniqueConstraint = 2627;

    }
}
