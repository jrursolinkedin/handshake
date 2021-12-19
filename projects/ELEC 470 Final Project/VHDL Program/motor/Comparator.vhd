LIBRARY IEEE;
USE IEEE.std_logic_1164.all;

ENTITY Comparator IS 
    GENERIC( n : integer := 25);
	 PORT(
	      in_value : in std_logic_vector(n-1 downto 0);
			Ref      : in std_logic_vector(24 downto 0);
			Comp_out : out std_logic
			
	     );
END ENTITY;

ARCHITECTURE ComparatorBehave OF Comparator IS 

BEGIN

Process(in_value,Ref)
begin

    if in_value = Ref then
	    Comp_out <= '1';
	 else
	    Comp_out <= '0';
    end if;

end process;

END ARCHITECTURE;