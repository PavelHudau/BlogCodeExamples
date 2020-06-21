class Duck:
    def __init__(self, duck_index):
        self._duck_index = duck_index

    def quack(self):
        return f"Quack : {self._duck_index}"


class Farm:
    def what_duck_says(self, duck):
        return duck.quack()

    def animals_talk(self):
        # OK
        duck_1 = Duck(1)

        # OK
        # We don't have to be explicit about types,
        # so the code below works for now. But it hides
        # a potential problem and can turn into a "time bomb".
        duck_2 = new Duck("2")

        # OK
        var what_duck_1_said = self.what_duck_says(duck_1)

        # RUNTIME ERROR
        # String is passed as argument to what_duck_says, so
        # attribute error will be thrown on runtime, because
        # a string does not have quack attribure
        var whatDuck2Said = self.what_duck_says("A Duck")
