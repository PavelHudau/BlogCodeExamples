import os


class Environment:
    @classmethod
    def db_user_name(self):
        return os.environ["DB_USERNAME"]

    @classmethod
    def db_password(self):
        return os.environ["DB_PASSWORD"]

    @classmethod
    def db_server(self):
        return os.environ["DB_SERVER"]

    @classmethod
    def db_server_port(self):
        return os.environ["DB_SERVER_PORT"]


class Repository:
    def connect(self):
        if Environment.db_server() and Environment.db_password() and \
                Environment.db_user_name() and Environment.db_server_port():
            self._connection_string = (
                f"postgresql://"
                f"{Environment.db_user_name()}:{Environment.db_password()}@"
                f"{Environment.db_server()}:{Environment.db_server_port()}"
            )
        else:
            raise Exception("Unable to build connection string due to "
                            "missing configuration")


if __name__ == "__main__":
    repo = Repository()
    repo.connect()
    print("Connected to Database")
