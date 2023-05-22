package roman.numerals;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.util.stream.Stream;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.params.provider.Arguments.of;
import static roman.numerals.RomanNumerals.convert;

class RomanNumeralsTest {
    private static Stream<Arguments> passingExamples() {
        return Stream.of(
                of(1, "I"),
                of(3, "III"),
                of(4, "IV"),
                of(5, "V"),
                of(10, "X"),
                of(13, "XIII"),
                of(50, "L"),
                of(100, "C"),
                of(500, "D"),
                of(1000, "M"),
                of(2499, "MMCDXCIX")
        );
    }

    @Test
    void generate_none_for_0() {
        assertThat(convert(0))
                .isEmpty();
    }

    @ParameterizedTest()
    @MethodSource("passingExamples")
    void generate_roman_for_decimal_numbers(int number, String expectedRoman) {
        assertThat(convert(number))
                .isPresent()
                .contains(expectedRoman);
    }
}