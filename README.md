# EventIntegrator
Event Integrator Project include:

EventIntegrator - application perform requests to TicketMaster and SeakGeek APIs and store events in DB
EventsApi - WebAPI aplication which provide Events details from resoures stored by EventIntegrator
To run EventIntegrator please update data source in DB connection string in app.config file to use DB installed on your local:

In Package Manager console run: Update-Database - in project EF code first approach was used

When application would be started get requests to events provider will be performed and retrieved data will be casted to common event format and DB records will be updated.

To run EventApi please update Data Source in appsettings.json file to reflect you local DB. When application will be running please navigate in web browser to http://localhost:12962/swagger/index.html to view collection of data types and available resources.
