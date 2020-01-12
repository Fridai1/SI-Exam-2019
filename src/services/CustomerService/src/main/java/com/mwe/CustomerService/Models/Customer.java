package com.mwe.CustomerService.Models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "`Customers`")
public class Customer {
	
	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	@Column(name="id")
	private Integer id;
	@Column(name="first_name")
	private String firstName;
	@Column(name="last_name")
	private String lastName;
	@Column(name="drivers_license")
	private String driversLicense;
	@Column(name="address")
	private String address;
	@Column(name="city")
	private String city;
	
	
	public Customer() {
		
	}


	public Customer(String firstName, String lastName, String driversLicense, String address, String city) {
		super();
		this.firstName = firstName;
		this.lastName = lastName;
		this.driversLicense = driversLicense;
		this.address = address;
		this.city = city;
	}


	public String getFirstName() {
		return firstName;
	}


	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}


	public String getLastName() {
		return lastName;
	}


	public void setLastName(String lastName) {
		this.lastName = lastName;
	}


	public String getDriversLicense() {
		return driversLicense;
	}


	public void setDriversLicense(String driversLicense) {
		this.driversLicense = driversLicense;
	}


	public String getAddress() {
		return address;
	}


	public void setAddress(String address) {
		this.address = address;
	}


	public String getCity() {
		return city;
	}


	public void setCity(String city) {
		this.city = city;
	}
}
