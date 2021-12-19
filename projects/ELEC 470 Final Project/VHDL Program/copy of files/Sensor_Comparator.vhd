library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Sensor_Comparator is
	generic(cycles : integer:= 22);
	port(
		count_cycles_in : in std_logic_vector(cycles-1 downto 0);
		reference_one : in std_logic_vector(cycles-1 downto 0);
		reference_two : in std_logic_vector(cycles-1 downto 0);
		comparator_out : out std_logic
	);
end entity;

architecture behave of Sensor_Comparator is
begin
	
	-- Updates output value "comparator_out".
	process(count_cycles_in)
	begin
	
		if (count_cycles_in = reference_one) or (count_cycles_in = reference_two) then
			comparator_out <= '1';
		else
			comparator_out <= '0';
		end if;
	
	end process;

end architecture;