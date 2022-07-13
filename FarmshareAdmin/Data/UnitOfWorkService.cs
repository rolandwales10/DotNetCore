using mdl = FarmshareAdmin.Models;

/*
 *  This class manages the creation of instances of the FarmshareEntities dbset, and provides a method to save changes.
 *  It can be used to commit changes from one or more entities as a single transaction.
 */

namespace FarmshareAdmin.Data
{
    public class UnitOfWorkService : IDisposable
    {
        public mdl.ACF_FarmshareContext _context;
        ILogger _logger;
        private ErrorService error;

        public UnitOfWorkService(mdl.ACF_FarmshareContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            error = new ErrorService(_logger);
        }

        public async Task<List<Message>> SaveAsync(string locationIdentifier)
        {
            List<Message> messages = new();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException du)
            {
                MessageService.AddErrorMessage(messages, du.InnerException.ToString());
            }
            catch (Exception ex)
            {
                error.logError(locationIdentifier, ex);
                MessageService.AddErrorMessage(messages, "Database detected error - contact OIT support");
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
