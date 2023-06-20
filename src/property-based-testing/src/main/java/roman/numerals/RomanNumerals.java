package roman.numerals;

import java.util.Comparator;
import java.util.Map;
import java.util.Optional;
import java.util.TreeMap;

import static java.util.Optional.empty;
import static java.util.Optional.of;

public final class RomanNumerals {
    private static final Map<Integer, String> intToNumerals = createMapForIntegerToNumerals();

    private static TreeMap<Integer, String> createMapForIntegerToNumerals() {
        var map = new TreeMap<Integer, String>(Comparator.reverseOrder());
        map.put(1000, "M");
        map.put(900, "FM");
        map.put(500, "D");
        map.put(400, "CD");
        map.put(100, "C");
        map.put(90, "XC");
        map.put(50, "L");
        map.put(40, "XL");
        map.put(10, "X");
        map.put(9, "IX");
        map.put(5, "V");
        map.put(4, "IV");
        map.put(1, "I");

        return map;
    }

    public static Optional<String> convert(int number) {
        if (number != 0) {
            var roman = new StringBuilder();
            var remaining = number;

            for (var toRoman : intToNumerals.entrySet()) {
                while (remaining >= toRoman.getKey()) {
                    roman.append(toRoman.getValue());
                    remaining -= toRoman.getKey();
                }
            }
            return of(roman.toString());
        } else {
            return empty();
        }
    }
}