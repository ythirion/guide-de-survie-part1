package roman.numerals;

import java.util.Comparator;
import java.util.Map;
import java.util.Optional;
import java.util.TreeMap;

import static java.util.Optional.empty;
import static java.util.Optional.of;

public final class RomanNumerals {
    private static final int MAX_DECIMAL = 3999;
    private static final Map<Integer, String> decimalToNumerals = createMapForDecimalToNumerals();

    private static TreeMap<Integer, String> createMapForDecimalToNumerals() {
        var map = new TreeMap<Integer, String>(Comparator.reverseOrder());
        map.put(1000, "M");
        map.put(900, "CM");
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

    public static Optional<String> convert(int decimalNumber) {
        return isInRange(decimalNumber)
                ? convertSafely(decimalNumber)
                : empty();
    }

    private static Optional<String> convertSafely(int decimalNumber) {
        var roman = new StringBuilder();
        var remaining = decimalNumber;

        for (var decimalToNumber : decimalToNumerals.entrySet()) {
            while (remaining >= decimalToNumber.getKey()) {
                roman.append(decimalToNumber.getValue());
                remaining -= decimalToNumber.getKey();
            }
        }
        return of(roman.toString());
    }

    private static boolean isInRange(int decimalNumber) {
        return decimalNumber > 0 && decimalNumber <= MAX_DECIMAL;
    }
}