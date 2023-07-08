1) Implement rest of Company controller functions, all the way down to data access layer

2) Change all Company controller functions to be asynchronous

3) Create new repository to get and save employee information with the following data model properties:

* string SiteId,
* string CompanyCode,
* string EmployeeCode,
* string EmployeeName,
* string Occupation,
* string EmployeeStatus,
* string EmailAddress,
* string Phone,
* DateTime LastModified

4) Create employee controller to get the following properties for client side:

* string EmployeeCode,
* string EmployeeName,
* string CompanyName,
* string OccupationName,
* string EmployeeStatus,
* string EmailAddress,
* string PhoneNumber,
* string LastModifiedDateTime

5) Add logger to solution and add proper error handling

## Testing via Curl Commands
You can run the application with VSC. Ensure your run configuration is set to use Single startup project and is pointing to WebApi. Then while its running, you can run the following commands in your terminal to test the program.

#Create Company:
curl -X POST -H "Content-Type: application/json" -d '{
    "CompanyName": "Example Company",
    "AddressLine1": "123 Main St",
    "AddressLine2": "Suite 456",
    "AddressLine3": "Building C",
    "PostalZipCode": "12345",
    "PhoneNumber": "555-1234",
    "FaxNumber": "555-5678",
    "EquipmentCompanyCode": "EQC123",
    "Country": "United States",
    "ArSubledgers": [
        {
            "SubledgerName": "Subledger 1",
            "AccountNumber": "123456789"
        },
        {
            "SubledgerName": "Subledger 2",
            "AccountNumber": "987654321"
        }
    ],
    "LastModified": "2023-07-08T12:34:56"
}' http://localhost:51480/api/company

#Get Companies
curl -X GET http://localhost:51480/api/company/getall

#Get Company
curl -X GET http://your-api-endpoint.com/api/company/1

#Updating a Company
curl -X PUT -H "Content-Type: application/json" -d '{
    "CompanyName": "Updated Company Name",
    "AddressLine1": "Updated Address Line 1",
    "AddressLine2": "Updated Address Line 2",
    "AddressLine3": "Updated Address Line 3",
    "PostalZipCode": "Updated Postal/Zip Code",
    "PhoneNumber": "Updated Phone Number",
    "FaxNumber": "Updated Fax Number",
    "EquipmentCompanyCode": "Updated Equipment Company Code",
    "Country": "Updated Country",
    "ArSubledgers": [
        {
            "SubledgerName": "Updated Subledger 1",
            "AccountNumber": "Updated Account Number 1"
        },
        {
            "SubledgerName": "Updated Subledger 2",
            "AccountNumber": "Updated Account Number 2"
        }
    ],
    "LastModified": "2023-07-08T12:34:56"
}' http://your-api-endpoint.com/api/company/1

#Deleting a Company
curl -X DELETE http://your-api-endpoint.com/api/company/1