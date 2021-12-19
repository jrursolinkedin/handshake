library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Distance_Decoder is
	generic(dist : integer:= 4; segment : integer := 7);
	port(
		distance_in_one : in std_logic_vector(dist-1 downto 0);
		distance_in_ten : in std_logic_vector(dist-1 downto 0);
		distance_in_hundred : in std_logic_vector(dist-1 downto 0);
		display_out_one : out std_logic_vector(segment-1 downto 0);
		display_out_ten : out std_logic_vector(segment-1 downto 0);
		display_out_hundred : out std_logic_vector(segment-1 downto 0)
	);
end entity;

architecture behave of Distance_Decoder is
begin

	display_out_one 		<= "0000001";

	display_out_ten 		<=	"0000001" when distance_in_ten = "0000" else 
									"1001111" when distance_in_ten = "0001" else
									"0010010" when distance_in_ten = "0010" else
									"0000110" when distance_in_ten = "0011" else
									"1001100" when distance_in_ten = "0100" else
									"0100100" when distance_in_ten = "0101" else
									"0100000" when distance_in_ten = "0110" else
									"0001111" when distance_in_ten = "0111" else
									"0000000" when distance_in_ten = "1000" else
									"0000100" when distance_in_ten = "1001" else
									"1111111";
								
	display_out_hundred	<= "1001111" when distance_in_hundred = "0001" else
									"0010010" when distance_in_hundred = "0010" else
									"1111111";
				
end architecture;