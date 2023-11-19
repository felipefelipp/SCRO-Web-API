select Sum(R.ValorResposta) ValorResposta, 
		   CP.ClassificacaoPacienteId,
		   CP.PacienteId,
		   0 ResultadoCor
	from ClassificacaoPaciente CP
		inner join RespostaSelecionadaPaciente RSP
			on (CP.ClassificacaoPacienteId = RSP.ClassificacaoPacienteId)
		inner join Resposta R
			on (RSP.RespostaId = R.RespostaId)
	where CP.ClassificacaoPacienteId = @ClassificacaoPacienteId
group by CP.ClassificacaoPacienteId,
		 CP.PacienteId
		 

			