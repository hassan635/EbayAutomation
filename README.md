# EbayAutomation

To assess the design of the automation framework for web application, I usally start out by writing a smoke test. Although in this case, due to time constraints I started out with writing the given scenario in the exercise.

Going through the steps for the given user story, I observed that, generally, the ebay shop and checkout process has a certain pattern to the way a typical user will perform the steps. For example, if someone wants to buy an Ultrabook from ebay, they will follow these steps:

- Step#1: Log-in to ebay.
- Step#2: From the Home page, they'll select one of the main categories(in this case Laptops & Notebooks) of a product.
- Step#3: Then they'll select a brand from the top 5 that are displayed.
- Step#4: They'll select a particular type of the product that the brand offers(in this case an Ultrabook).
- Step#5: On the selected product type page, a list of available products will be present. They'll select one of the listings.
- Step#6: On the product's page, they'll will press the Buy Now button which takes them to the checkout page.
- Step#7: On the checkout page, they'll review their order and pay.

Based on the steps above, a generic pattern of user behaviour can be implemented in the automation framework which is:

- A main category interface which can then be used for creating any concrete classes for currently available categories as well as future additions, with out modifying the existing tests and page classes that used them.
- A brand category interface which can then be used for creating any concrete classes for currently available brand categories as well as future additions, with out modifying the existing tests and page classes that used them.
- A product type interface which can then be used for creating any concrete classes for currently available types as well as future additions, with out modifying the existing tests and page classes that used them.
- A product interface which can then be used for creating any concrete classes for currently available product listings as well as future additions, with out modifying the existing tests and page classes that used them.

Also, to automate the testing of the large number of categories and products on ebay, the above approach keeps the framework generic and the knowledge about which concrete page classes to instantiate is pushed out to test-date.csv from where it's just a matter of adding the required pages and the framework will take care of the rest.

Additionally, since their are so many different types of navigation available on ebay, therefore it is refactored out of the page classes and has it's own interface. For the given exercise, only the top level navigation is tested at each stage of the checkout test.

For cross browser testing support, a driver factory is implemented which accepts information about which browsers are required to be instantiated for a test from browser-config.csv.

More details about how the framework works and various components like custom dynamic waiting strategies can be found by going through the above code. Also, the refactoring done in the framework are by no means exhaustive and as with any software architecture gets introduced as the code matures.

The code provided might have a few errors, however, as it mentioned in the exercise, the point was to clearly convey the approach and not necessarily provide a fully tested automation framework.

Happy to answer more questions around it during the interview. Thank you and have a great day.

Hasan
