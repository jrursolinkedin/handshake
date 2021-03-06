library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Sensor_Counter is
	generic(cycles : integer:= 22);
	port(
		clk : in std_logic;
		reset : in std_logic;
		enable : in std_logic;
		count_cycles : out std_logic_vector(cycles-1 downto 0)
	);
end entity;

architecture behave of Sensor_Counter is

	signal internal_count : std_logic_vector(cycles-1 downto 0) := (others=>'0');
	signal add_out : std_logic_vector(cycles-1 downto 0) := (others=>'0');

begin

	-- Update "count_cycles".
	count_cycles <= internal_count;
	
	-- Adder:
	process(enable, internal_count)
	begin
	
		if enable = '1' then
			add_out <= std_logic_vector(unsigned(internal_count)+1);
		else
			add_out <= std_logic_vector(unsigned(internal_count)+0);
		end if;
		
	end process;
	
	-- Register:
	process(clk, reset, add_out)
	begin
	
		if reset = '1' then
			internal_count <= (others=>'0');
		elsif rising_edge(clk) then
			internal_count <= add_out;
		end if;
	
	end process;

end architecture;