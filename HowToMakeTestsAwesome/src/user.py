class User():
    def __init__(self):
        self._is_authenticated = False

    @property
    def is_authenticcated(self):
        return self._is_authenticated

    def authenticate(self):
        self._is_authenticated = True