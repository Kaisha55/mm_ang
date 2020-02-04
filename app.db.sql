BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "AspNetRoles" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT,
	"NormalizedName"	TEXT,
	"ConcurrencyStamp"	TEXT,
	CONSTRAINT "PK_AspNetRoles" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "AspNetUsers" (
	"Id"	TEXT NOT NULL,
	"UserName"	TEXT,
	"NormalizedUserName"	TEXT,
	"Email"	TEXT,
	"NormalizedEmail"	TEXT,
	"EmailConfirmed"	INTEGER NOT NULL,
	"PasswordHash"	TEXT,
	"SecurityStamp"	TEXT,
	"ConcurrencyStamp"	TEXT,
	"PhoneNumber"	TEXT,
	"PhoneNumberConfirmed"	INTEGER NOT NULL,
	"TwoFactorEnabled"	INTEGER NOT NULL,
	"LockoutEnd"	TEXT,
	"LockoutEnabled"	INTEGER NOT NULL,
	"AccessFailedCount"	INTEGER NOT NULL,
	CONSTRAINT "PK_AspNetUsers" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "DeviceCodes" (
	"UserCode"	TEXT NOT NULL,
	"DeviceCode"	TEXT NOT NULL,
	"SubjectId"	TEXT,
	"ClientId"	TEXT NOT NULL,
	"CreationTime"	TEXT NOT NULL,
	"Expiration"	TEXT NOT NULL,
	"Data"	TEXT NOT NULL,
	CONSTRAINT "PK_DeviceCodes" PRIMARY KEY("UserCode")
);
CREATE TABLE IF NOT EXISTS "PersistedGrants" (
	"Key"	TEXT NOT NULL,
	"Type"	TEXT NOT NULL,
	"SubjectId"	TEXT,
	"ClientId"	TEXT NOT NULL,
	"CreationTime"	TEXT NOT NULL,
	"Expiration"	TEXT,
	"Data"	TEXT NOT NULL,
	CONSTRAINT "PK_PersistedGrants" PRIMARY KEY("Key")
);
CREATE TABLE IF NOT EXISTS "AspNetRoleClaims" (
	"Id"	INTEGER NOT NULL,
	"RoleId"	TEXT NOT NULL,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY("Id" AUTOINCREMENT),
	CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY("RoleId") REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserClaims" (
	"Id"	INTEGER NOT NULL,
	"UserId"	TEXT NOT NULL,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY("Id" AUTOINCREMENT),
	CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserLogins" (
	"LoginProvider"	TEXT NOT NULL,
	"ProviderKey"	TEXT NOT NULL,
	"ProviderDisplayName"	TEXT,
	"UserId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY("LoginProvider","ProviderKey"),
	CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserRoles" (
	"UserId"	TEXT NOT NULL,
	"RoleId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY("UserId","RoleId"),
	CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY("RoleId") REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserTokens" (
	"UserId"	TEXT NOT NULL,
	"LoginProvider"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Value"	TEXT,
	CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY("UserId","LoginProvider","Name"),
	CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('00000000000000_CreateIdentitySchema','3.0.0-rc1.19455.8');
INSERT INTO "AspNetUsers" ("Id","UserName","NormalizedUserName","Email","NormalizedEmail","EmailConfirmed","PasswordHash","SecurityStamp","ConcurrencyStamp","PhoneNumber","PhoneNumberConfirmed","TwoFactorEnabled","LockoutEnd","LockoutEnabled","AccessFailedCount") VALUES ('7c92d733-9bf8-4e83-98ac-f35d7a2458ac','kaisha55@gmail.com','KAISHA55@GMAIL.COM','kaisha55@gmail.com','KAISHA55@GMAIL.COM',0,'AQAAAAEAACcQAAAAEAvVd2vXShQTydYE9PkhtFa/u5znXJbXkmb15ifUBDrD4zkkmaZ1FJ+uFEOIp7R+Vw==','7NBQVKD3RQBHLNGQSZMU65WUPQTJE2RF','4f7bf25f-c671-4be8-9a90-913c7dbb7981',NULL,0,0,NULL,1,0);
CREATE INDEX IF NOT EXISTS "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" (
	"RoleId"
);
CREATE UNIQUE INDEX IF NOT EXISTS "RoleNameIndex" ON "AspNetRoles" (
	"NormalizedName"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" (
	"RoleId"
);
CREATE INDEX IF NOT EXISTS "EmailIndex" ON "AspNetUsers" (
	"NormalizedEmail"
);
CREATE UNIQUE INDEX IF NOT EXISTS "UserNameIndex" ON "AspNetUsers" (
	"NormalizedUserName"
);
CREATE UNIQUE INDEX IF NOT EXISTS "IX_DeviceCodes_DeviceCode" ON "DeviceCodes" (
	"DeviceCode"
);
CREATE INDEX IF NOT EXISTS "IX_DeviceCodes_Expiration" ON "DeviceCodes" (
	"Expiration"
);
CREATE INDEX IF NOT EXISTS "IX_PersistedGrants_Expiration" ON "PersistedGrants" (
	"Expiration"
);
CREATE INDEX IF NOT EXISTS "IX_PersistedGrants_SubjectId_ClientId_Type" ON "PersistedGrants" (
	"SubjectId",
	"ClientId",
	"Type"
);
COMMIT;
