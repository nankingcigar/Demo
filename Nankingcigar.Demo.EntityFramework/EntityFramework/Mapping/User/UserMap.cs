using System.Data.Entity.ModelConfiguration;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Mapping.User
{
    public class UserMap : EntityTypeConfiguration<Core.Entity.User.User>
    {
        public UserMap()
        {
            this.Property(e => e.UserName).HasColumnName("Name");

            this.HasMany(e => e.CreatedUsers)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedUsers)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedUsers)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            this.HasMany(e => e.UserAuditLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);
            this.HasMany(e => e.ImpersonatorAuditLogs)
                .WithOptional(e => e.Impersonator)
                .HasForeignKey(e => e.ImpersonatorUserId);

            this.HasMany(e => e.CreatedRoles)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedRoles)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedRoles)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            this.HasMany(e => e.CreatedApis)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedApis)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedApis)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            this.HasMany(e => e.CreatedRoleApis)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedRoleApis)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedRoleApis)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            this.HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);
            this.HasMany(e => e.CreatedRoleUsers)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedRoleUsers)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedRoleUsers)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);

            this.HasMany(e => e.UserApis)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);
            this.HasMany(e => e.CreatedUserApis)
                .WithOptional(e => e.CreatorUser)
                .HasForeignKey(e => e.CreatorUserId);
            this.HasMany(e => e.LastModifiedUserApis)
                .WithOptional(e => e.LastModifierUser)
                .HasForeignKey(e => e.LastModifierUserId);
            this.HasMany(e => e.DeletedUserApis)
                .WithOptional(e => e.DeleterUser)
                .HasForeignKey(e => e.DeleterUserId);
        }
    }
}