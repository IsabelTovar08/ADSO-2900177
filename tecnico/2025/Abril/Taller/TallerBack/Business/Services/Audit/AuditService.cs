using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Models.AuditLog;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Audit
{
    public class AuditService
    {
        private readonly AuditDbContext _auditDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditService(AuditDbContext auditDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _auditDbContext = auditDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogAuditAsync(string entityName, EntityState action, object oldValues, object newValues)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

            var auditLog = new AuditLog
            {
                EntityName = entityName,
                Action = action.ToString(),
                OldValue = oldValues != null ? JsonSerializer.Serialize(oldValues) : null,
                NewValue = newValues != null ? JsonSerializer.Serialize(newValues) : null,
                UserId = userId,
                Timestamp = DateTime.UtcNow
            };

            _auditDbContext.AuditLogs.Add(auditLog);
            await _auditDbContext.SaveChangesAsync();
        }
    }
}
