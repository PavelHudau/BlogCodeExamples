def divide(dividend, divisor):
    return dividend / divisor


def try_divide(dividend, divisor):
    try:
        return (dividend / divisor, True)
    except ZeroDivisionError:
        return (None, False)
