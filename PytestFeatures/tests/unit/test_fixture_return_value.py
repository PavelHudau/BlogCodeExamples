import pytest


class DbConnection():
    def __init__(self):
        self.is_open = True

    def open(self):
        self.is_open = True
        print("DB connection is open")

    def execute_query(self, query):
        if not self.is_open:
            raise Exception("Connection is not open")
        print(f"Executing DB query: {query}")

    def close(self):
        self.is_open = False
        print("DB connection is closed")


@pytest.fixture
def db_connection():
    db_con = DbConnection()
    db_con.open()
    yield db_con
    db_con.close()


def test_fixture_returns_value(db_connection):
    db_connection.execute_query("SELECT * FROM dbo.Cats")
    # Make test fail to see the output
    assert True
