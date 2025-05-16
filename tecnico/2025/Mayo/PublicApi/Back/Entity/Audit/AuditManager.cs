using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Entity.Audit
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

            foreach (var entry in entries)
            {
                var entityName = entry.Entity.GetType().Name;
                var action = entry.State;

                object? oldValues = null;
                object? newValues = null;
                List<string> changedColumns = new();

                if (action == EntityState.Added)
                {
                    newValues = entry.CurrentValues.ToObject();
                }
                else if (action == EntityState.Deleted)
                {
                    oldValues = entry.OriginalValues.ToObject();
                }
                else if (action == EntityState.Modified)
                {
                    oldValues = entry.OriginalValues.ToObject();
                    newValues = entry.CurrentValues.ToObject();

                    foreach (var prop in entry.OriginalValues.Properties)
                    {
                        var original = entry.OriginalValues[prop];
                        var current = entry.CurrentValues[prop];
                        if (!Equals(original, current))
                        {
                            changedColumns.Add(prop.Name);
                        }
                    }
                }

                await _auditService.LogAuditAsync(entityName, action, oldValues, newValues, changedColumns);
            }
        }

    }
}
