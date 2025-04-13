INSERT INTO Employee	(ID, Name, ManagerID, Enable) VALUES
						(1, 'Andrey', NULL, 1),     -- root
						(2, 'Alexey', 1, 1),        -- Alexey —> Andrey
						(3, 'Nir', 2, 1),           -- Nir —>Alexey
						(4, 'Smadar', 3, 1),        -- Smadar —> Nir
						(5, 'Barak', 3, 1);         -- Barak —>Nir