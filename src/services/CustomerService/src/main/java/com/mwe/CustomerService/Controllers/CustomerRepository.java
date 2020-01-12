package com.mwe.CustomerService.Controllers;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.web.bind.annotation.RequestParam;

import com.mwe.CustomerService.Models.Customer;

public interface CustomerRepository extends CrudRepository<Customer, Integer> {

	@Query(value = "Select c.id, c.first_name, c.last_name, c.drivers_license, c.address, c.city FROM customers c WHERE c.drivers_license = :driversLicense", nativeQuery = true)
	public Customer findByDriversLicense(@RequestParam("driversLicense") String driversLicense);

}
