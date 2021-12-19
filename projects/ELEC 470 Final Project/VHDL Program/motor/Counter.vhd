LIBRARY IEEE;

USE IEEE.std_logic_1164.all;
USE IEEE.numeric_std.all;

ENTITY COUNTER IS 
    GENERIC( n : integer := 25);
	 PORT(
	      clk : in std_logic;
			rst : in std_logic;
			Cntr_En  : in std_logic;
			cnt : out std_logic_vector(n-1 downto 0)
			
	     );
END ENTITY;

ARCHITECTURE CounterBehave OF COUNTER IS 
SIGNAL INTERNAL_COUNT : std_logic_vector(n-1 downto 0):= "0000000000000000000000000";
SIGNAL Add_out        : std_logic_vector(n-1 downto 0):= "0000000000000000000000000";
BEGIN
--Adder
Process(Cntr_En,INTERNAL_COUNT)
Begin
    if Cntr_En = '1' then
	         Add_out <= std_logic_vector(signed(internal_count) + 1);
	 else
	         Add_out <= std_logic_vector(signed(internal_count) + 0);
	 end if;
end process;

Process(clk,rst,Add_out)
Begin
   if rst = '1' then 
	    internal_count <= (OTHERS => '0');
	elsif rising_edge(clk) then
	    internal_count <= Add_out;
	end if;

End Process;



cnt <= INTERNAL_COUNT;

END ARCHITECTURE;