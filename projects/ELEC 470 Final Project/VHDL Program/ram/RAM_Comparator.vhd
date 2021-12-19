library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity RAM_Comparator is
	generic(cnt : integer:= 8);
	port(
		count_in : in std_logic_vector(cnt-1 downto 0);
		reference : in std_logic_vector(cnt-1 downto 0);
		comparator_out : out std_logic
	);
end entity;

architecture behave of RAM_Comparator is
begin
	
	-- Updates output value "comparator_out".
	process(count_in)
	begin
	
		if count_in = reference then
			comparator_out <= '1';
		else
			comparator_out <= '0';
		end if;
	
	end process;

end architecture;