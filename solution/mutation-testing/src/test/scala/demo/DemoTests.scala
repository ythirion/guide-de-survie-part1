package demo

import demo.Demo.isLong
import org.scalatest.flatspec.AnyFlatSpec

class DemoTests extends AnyFlatSpec {
  it should "return false for abc String" in {
    assert(!isLong("abc"))
  }

  it should "return true for abcdef String" in {
    assert(isLong("abcdef"))
  }

  it should "return false for abcde String" in {
    assert(!isLong("abcde"))
  }
}