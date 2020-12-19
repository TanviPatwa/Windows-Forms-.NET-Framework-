# Windows Forms (.NET-Framework)
This repository contains simple Windows Forms Projects with practical use.

# Super Market
A windows application which provides friendly UI to add companies and their orders, displaying details by grouping orders under companies.
There are 3 main parts of the Windows Form
1. Master
User can add companies from where he/she has to order products. This data is displayed in View tab. Firstly we need to add company details before placing order in Item tab.
2. Item
The portal allows you to add the order with unique order id which is generated automatically and date-time is taken from the system. Also the company name is shown in dropdown as added in Master tab.
3. View
This allows us to view the Item-Master. Initially what you will see is company details in a table, as soon as you double click on row it will display all orders which are to be ordered from that company. 
So basically it is relation between two list<Objects> created in Windows forms using c#
