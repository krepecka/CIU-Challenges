
def main():
    test_arr = range(0, 21)

    print binary_search(133, test_arr)
    print binary_search_recursive(133, test_arr, len(test_arr) - 1, 0)

    print binary_search(16, test_arr)
    print binary_search_recursive(13, test_arr, len(test_arr) - 1, 0)


def binary_search_recursive(value, array, hi, lo):
    if lo > hi:
        return -1

    guess_index = (hi + lo) / 2

    if array[guess_index] == value:
        return guess_index
    elif array[guess_index] > value:
        return binary_search_recursive(value, array, guess_index - 1, lo)
    elif array[guess_index] < value:
        return binary_search_recursive(value, array, hi, guess_index + 1)

    return -1


def binary_search(value, array):
    hi = len(array) - 1
    lo = 0

    while hi >= lo:
        guess_index = (hi + lo) / 2

        if array[guess_index] == value:
            break
        elif array[guess_index] > value:
            hi = guess_index - 1
        elif array[guess_index] < value:
            lo = guess_index + 1

    return guess_index if hi >= lo else -1


if __name__ == "__main__":
    main()
