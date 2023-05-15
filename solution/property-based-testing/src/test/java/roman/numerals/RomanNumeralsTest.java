package roman.numerals;

import io.vavr.test.Gen;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.util.stream.Stream;

import static io.vavr.test.Property.def;
import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.params.provider.Arguments.of;
import static roman.numerals.RomanNumerals.convert;

class RomanNumeralsTest {
    private static Stream<Arguments> passingExamples() {
        return Stream.of(
                of(1, "I"),
                of(3, "III"),
                of(5, "V"),
                of(10, "X"),
                of(50, "L"),
                of(100, "C"),
                of(500, "D"),
                of(1000, "M")
        );
    }

    @ParameterizedTest()
    @MethodSource("passingExamples")
    void generate_roman_for_decimal_numbers(int number, String expectedRoman) {
        assertThat(convert(number))
                .isPresent()
                .contains(expectedRoman);
    }

    @Test
    void returns_empty_for_any_decimal_out_of_range() {
        var invalidDecimal = Gen.choose(-10_000, 10_000)
                .arbitrary()
                .filter(x -> x <= 0 || x > 3999);

        def("empty for numbers <= 0 or > 3999")
                .forAll(invalidDecimal)
                .suchThat(decimal -> convert(decimal).isEmpty())
                .check()
                .assertIsSatisfied();
    }

    @Test
    void refactoring_property() {
        // This property can help us refactor code safely without switching all existing tests on the new implementation
        // Can be useful if you want to refactor for performance reason for example
        def("f(x) = new_f(x)")
                .forAll(Gen.choose(-10_000, 10_000).arbitrary())
                .suchThat(decimal ->
                        RomanNumerals
                                .convert(decimal)
                                .equals(RomanNumeralsV2.convert(decimal))
                )
                .check()
                .assertIsSatisfied();
    }
}