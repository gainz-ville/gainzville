FROM mcr.microsoft.com/mssql/server:2019-latest AS build
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=GainzPassword123!

# This method of database migration will require idempotent SQL scripts for schema and data migration

WORKDIR /tmp
COPY smoke-test.sql .

# COPY a backup here if required, then restore in SQL script

RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 10 \
	&& /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "GainzPassword123!" -i /tmp/smoke-test.sql \
	&& pkill sqlservr

# TO run another script add:
# && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "GainzPassword" -i /tmp/SCRIPT_HERE.sql \
# or just call multiple sql scripts from the main one
	
FROM mcr.microsoft.com/mssql/server:2019-latest AS release
ENV ACCEPT_EULA=Y

#COPY --from=build /var/opt/mssql/data /var/opt/mssql/data