package com.gildedrose;

import org.junit.jupiter.api.Test;

import static org.approvaltests.combinations.CombinationApprovals.verifyAllCombinations;

class GildedRoseTests {
    @Test
    void updateQuality() {
        verifyAllCombinations(
                this::updateQualityFor,
                new String[]{"a common item",
                        "Aged Brie",
                        "Backstage passes to a TAFKAL80ETC concert",
                        "Sulfuras, Hand of Ragnaros"},
                new Integer[]{-100, -1, 0, 1, 5, 6, 7, 10, 11, 12},
                new Integer[]{0, 1, 49, 50, 51}
        );
    }

    private String updateQualityFor(String name, int sellIn, int quality) {
        var items = new Item[]{new Item(name, sellIn, quality)};
        var gildedRose = new GildedRose(items);
        gildedRose.updateQuality();

        return gildedRose.items[0].toString();
    }
}