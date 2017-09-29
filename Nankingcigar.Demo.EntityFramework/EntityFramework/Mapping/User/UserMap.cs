using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.User
{
    public class UserMap : EntityTypeConfiguration<Core.Entity.User.User>
    {
        public UserMap()
        {
            this.Property(t => t.UserName).HasColumnName("Name");

            this.HasMany(t => t.UserAuditLogs)
                .WithOptional(t => t.User)
                .HasForeignKey(t => t.UserId);
            this.HasMany(t => t.ImpersonatorAuditLogs)
                .WithOptional(t => t.Impersonator)
                .HasForeignKey(t => t.ImpersonatorUserId);
            this.HasMany(t => t.UserRoles)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);
            this.HasMany(t => t.UserApis)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);
            this.HasMany(t => t.UserRoutes)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);

            this.HasMany(t => t.CreatedUsers)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedUsers)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedUsers)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);

            this.HasMany(t => t.CreatedRoles)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedRoles)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedRoles)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);

            this.HasMany(t => t.CreatedApis)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedApis)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedApis)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);

            this.HasMany(t => t.CreatedRoleApis)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedRoleApis)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedRoleApis)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);

            this.HasMany(t => t.CreatedRoleUsers)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedRoleUsers)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedRoleUsers)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);

            this.HasMany(t => t.CreatedUserApis)
                .WithOptional(t => t.CreatorUser)
                .HasForeignKey(t => t.CreatorUserId);
            this.HasMany(t => t.LastModifiedUserApis)
                .WithOptional(t => t.LastModifierUser)
                .HasForeignKey(t => t.LastModifierUserId);
            this.HasMany(t => t.DeletedUserApis)
                .WithOptional(t => t.DeleterUser)
                .HasForeignKey(t => t.DeleterUserId);
        }
    }
}