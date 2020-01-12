package com.mwe.CustomerService.Controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.mwe.CustomerService.Models.Customer;

import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;

@RestController
@RequestMapping("/Customers")
public class CustomerController {

	@Autowired 
	// This means to get the bean called customerRepository
	// Which is auto-generated by Spring, we will use it to handle the data
	private CustomerRepository customerRepository;

	@RequestMapping("/Create")
	public String createCustomer (@RequestParam String firstName, @RequestParam String lastName,
			@RequestParam String driversLicense, @RequestParam String address, @RequestParam String city) {
		// @ResponseBody means the returned String is the response, not a view name
		// @RequestParam means it is a parameter from the GET or POST request

		Customer c = new Customer(firstName, lastName, driversLicense, address, city);
		customerRepository.save(c);
		return "Customer created";
	}

	@RequestMapping("/All")
	public Iterable<Customer> getAllCustomers(){
		return customerRepository.findAll();
	}

	@RequestMapping(value = "/Id")
	public Optional<Customer> getCustomerById(@RequestParam(value = "Id", required = true) Integer id) {
		return customerRepository.findById(id);
	}

	@RequestMapping(value = "/DriversLicense")
	public Customer getCustomerByDriversLicense(@RequestParam(value = "Dl", required = true) String driversLicense) {
		return customerRepository.findByDriversLicense(driversLicense);
	}
}
