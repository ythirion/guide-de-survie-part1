package demo

import demo.customer.CustomerService._
import demo.customer.ProductType._
import demo.customer.{CustomerService, ProductType, Store}
import org.scalatest.TryValues.convertTryToSuccessOrFailure
import org.scalatest.flatspec.AnyFlatSpec

class CustomerTests extends AnyFlatSpec {
  val store: Store = new Store()
    .addInventory(Book, 10)

  it should "purchase successfully when enough inventory" in {
    assert(purchase(store, Book, 6)
      .success
      .value
      .getInventoryFor(Book) == 4)
  }

  it should "purchase successfully when quantity equals remaining in inventory" in {
    assert(purchase(store, Book, 10)
      .success
      .value
      .getInventoryFor(Book) == 0)
  }

  it should "fail to purchase when not enough inventory" in {
    val updatedStore = purchase(store, Book, 11)
    assert(updatedStore.isFailure)
    assert(updatedStore.failure.exception.getMessage == "Not enough inventory")
  }
}
