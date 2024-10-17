# Outline

Extend existing and add new functionallity to `giturb`

## Urbs

* `Extend /urbs endpoint with pageing and filtering`

  ```
  Add pageing and filter on name property, default pagesize=5
  ```
  *optional add sorting*

* `Extend the urb type with new properties`

  *Description (required)*
  ```
  Can you please add description property?
  ```
  
  *Spiciness (optional)*
  ```
  Can you also add a spice or spiciness property?
  ```
  *Add more urbs*
  ```
  Add X more urbs to the list in UrbsSeeder
  ```
  *in C# show difference inline vs chat*

## Basket
* `Create basket`
  ```
  Create a new BasketOfUrb. Its Id should be the maximum id + 1. Add it to the repository
  ```

* `Add urbs to the basket`
  ```
  Can you add urbs with the give urbId to the basket of basketId? 
  ```
  
## Test 

* `validity of basket`
  ```
  Add more tests to cover all the rules #file:BasketOfUrbs
  ```
  
* `naming convention`
  ```
  Use the following naming convention: MethodName_StateUnderTest_ExpectedBehavior
  ```

## Documentation

* `Generate documentation`
  
  ```
  Can you document the endpoint code so its available in swagger?
  ```

## Call to extarnal service

* `Post basket to giturb.api`
  
  ```
  Can you post my basket to https://giturb.playground.radix.equinor.com/make-me-happy endpoint. Map my basket with urb to the following request body { "id": 0, "happyUrbs": [ { "happyId": 0, "happyName": "string" } ] }
  ```
