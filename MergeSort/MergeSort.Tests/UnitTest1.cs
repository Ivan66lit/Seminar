using Microsoft.VisualStudio.TestPlatform.TestHost;
using MergeSort;

namespace MergeSort.Tests
{
    public class UnitTest1
    {

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Merge_EqualLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 3, 5, 2, 3, 6 };
            int[] expectedArray = { 1, 2, 3, 3, 5, 6 };
            int left = 0;
            int right = array.Length-1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Merge_DifferentLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 4, 7, 3, 6 };
            int[] expectedArray = { 1, 3, 4, 6, 7 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Merge_Duplicates_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 2, 2, 5, 8, 5, 6, 8 };
            int[] expectedArray = { 2, 2, 5, 5, 6, 8, 8 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Merge_ArrayWithNegativeNumbers_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { -5, -2, 0, -3, 1, 4 };
            int[] expectedArray = { -5, -3, -2, 0, 1, 4 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Merge_NotMiddle_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 3, 5, 9, 11, 2, 4, 6 };
            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 9, 11 };
            int left = 0;
            int right = array.Length - 1;
            int middle = 4;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        //Testy pro MergeSort//

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Sort_RandomArray_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 3, 5, 4, 80, 2 };
            int[] expectedArray = { 1, 2, 3, 4, 5, 80 };

            // Act - zavoláme testovanou funkci
            MergeSortClass.Sort(array);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Sort_Duplicates_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 7, 5, 1, 80, 7 };
            int[] expectedArray = { 1, 1, 5, 7, 7, 80 };

            // Act - zavoláme testovanou funkci
            MergeSortClass.Sort(array);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }

        [Fact]  // Tím označujeme, že jde o testovací metodu 
        public void Sort_ArrayWithNegativeNumbers_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, -3, 5, 4, 80, -2 };
            int[] expectedArray = { -3, -2, 1, 4, 5, 80 };

            // Act - zavoláme testovanou funkci
            MergeSortClass.Sort(array);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
    }
    
}
