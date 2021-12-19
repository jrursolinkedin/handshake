library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Distance_Calculator is
	generic(cycles : integer:= 21; dist : integer := 4);
	port(
		count : in std_logic_vector(cycles-1 downto 0);
		distance_one : out std_logic_vector(dist-1 downto 0);
		distance_ten : out std_logic_vector(dist-1 downto 0);
		distance_hundred : out std_logic_vector(dist-1 downto 0)
	);
end entity;

architecture behave of Distance_Calculator is
begin

	-- Updates the output values.
	process(count)
	begin
	
		-- 0 -> 10 cm
		if unsigned(count) <= 29000 then
			distance_one <= "0000";
			distance_ten <= "0001";
			distance_hundred <= "1010";
		-- 10 -> 20 cm
		elsif unsigned(count) <= 58000 then
			distance_one <= "0000";
			distance_ten <= "0010";
			distance_hundred <= "1010";
		-- 20 -> 30 cm
		elsif unsigned(count) <= 87000 then
			distance_one <= "0000";
			distance_ten <= "0011";
			distance_hundred <= "1010";
		-- 30 -> 40 cm
		elsif unsigned(count) <= 116000 then
			distance_one <= "0000";
			distance_ten <= "0100";
			distance_hundred <= "1010";
		-- 40 -> 50 cm
		elsif unsigned(count) <= 145000 then
			distance_one <= "0000";
			distance_ten <= "0101";
			distance_hundred <= "1010";
		-- 50 -> 60 cm
		elsif unsigned(count) <= 174000 then
			distance_one <= "0000";
			distance_ten <= "0110";
			distance_hundred <= "1010";
		-- 60 -> 70 cm
		elsif unsigned(count) <= 203000 then
			distance_one <= "0000";
			distance_ten <= "0111";
			distance_hundred <= "1010";
		-- 70 -> 80 cm
		elsif unsigned(count) <= 232000 then
			distance_one <= "0000";
			distance_ten <= "1000";
			distance_hundred <= "1010";
		-- 80 -> 90 cm
		elsif unsigned(count) <= 261000 then
			distance_one <= "0000";
			distance_ten <= "1001";
			distance_hundred <= "1010";
		-- 90 -> 100 cm
		elsif unsigned(count) <= 290000 then
			distance_one <= "0000";
			distance_ten <= "0000";
			distance_hundred <= "0001";
		-- 100 -> 110 cm
		elsif unsigned(count) <= 319000 then
			distance_one <= "0000";
			distance_ten <= "0001";
			distance_hundred <= "0001";
		-- 110 -> 120 cm
		elsif unsigned(count) <= 348000 then
			distance_one <= "0000";
			distance_ten <= "0010";
			distance_hundred <= "0001";
		-- 120 -> 130 cm
		elsif unsigned(count) <= 377000 then
			distance_one <= "0000";
			distance_ten <= "0011";
			distance_hundred <= "0001";
		-- 130 -> 140 cm
		elsif unsigned(count) <= 406000 then
			distance_one <= "0000";
			distance_ten <= "0100";
			distance_hundred <= "0001";
		-- 140 -> 150 cm
		elsif unsigned(count) <= 435000 then
			distance_one <= "0000";
			distance_ten <= "0101";
			distance_hundred <= "0001";
		-- 150 -> 160 cm
		elsif unsigned(count) <= 464000 then
			distance_one <= "0000";
			distance_ten <= "0110";
			distance_hundred <= "0001";
		-- 160 -> 170 cm
		elsif unsigned(count) <= 493000 then
			distance_one <= "0000";
			distance_ten <= "0111";
			distance_hundred <= "0001";
		-- 170 -> 180 cm
		elsif unsigned(count) <= 522000 then
			distance_one <= "0000";
			distance_ten <= "1000";
			distance_hundred <= "0001";
		-- 180 -> 190 cm
		elsif unsigned(count) <= 551000 then
			distance_one <= "0000";
			distance_ten <= "1001";
			distance_hundred <= "0001";
		-- 190 -> 200 cm
		elsif unsigned(count) <= 580000 then
			distance_one <= "0000";
			distance_ten <= "0000";
			distance_hundred <= "0010";
		-- 200 -> 400 cm
		else
			distance_one <= "0000";
			distance_ten <= "0000";
			distance_hundred <= "0010";
		end if;
		
	end process;

end architecture;