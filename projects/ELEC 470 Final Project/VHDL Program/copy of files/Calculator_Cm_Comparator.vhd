library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Calculator_Cm_Comparator is
	generic(cycles : integer:= 12);
	port(
		count_cycles_in : in std_logic_vector(cycles-1 downto 0);
		reference : in std_logic_vector(cycles-1 downto 0);
		comparator_out : out std_logic
	);
end entity;

architecture behave of Calculator_Cm_Comparator is
begin
	
	-- Updates output value "comparator_out".
	process(count_cycles_in)
	begin
	
		if count_cycles_in = reference then
			comparator_out <= '1';
		else
			comparator_out <= '0';
		end if;
	
	end process;

end architecture;