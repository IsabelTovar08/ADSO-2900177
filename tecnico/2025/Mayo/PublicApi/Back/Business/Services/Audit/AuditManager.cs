using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Business.Services.Audit
{
    public class AuditManager
    {
        private readonly AuditService _auditService;

        public AuditManager(AuditService auditService)
        {
            _auditService = auditService;
        }

        public async Task ProcessAuditLogsAsync(ChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                .ToList();

            foreach(var entry in entries)
            {
                var entityName = entry.Entity.GetType().Name;
                var action = entry.State;
                var oldValues = action == EntityState.Modified || action == EntityState.Deleted 
                    ? entry.OriginalValues.ToObject() : null;
                var newValues = action == EntityState.Added || action == EntityState.Modified
                    ? entry.CurrentValues.ToObject() : null;

                await _auditService.LogAuditAsync(entityName, action, oldValues, newValues);
            }
        }
    }
}
